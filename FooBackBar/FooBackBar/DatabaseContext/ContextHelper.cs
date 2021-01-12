using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FooBackBar.DatabaseContext.Attributes;

namespace FooBackBar.DatabaseContext
{
    public static class ContextHelper
    {
        public static void BuildEntities(this ModelBuilder modelBuilder, IEnumerable<Type> databaseModelTypes)
        {
            foreach(var modelType in databaseModelTypes)
            {
                modelBuilder.Entity(modelType).BuildEntites(modelType);
                modelBuilder.Entity(modelType).SeedEntities(modelType);
            }
        }

        public static void SeedEntities(this EntityTypeBuilder entityBuilder, Type modelType)
        {
            if (modelType.CustomAttributes != null &&
                 modelType.CustomAttributes.Any(x => x.AttributeType == typeof(Seeded)))
            {
                var seedMethod = modelType.GetMethod("GetSeeds");
                var instance = Activator.CreateInstance(modelType);
                object[] seeds = seedMethod.Invoke(instance, null) as object[];

                entityBuilder.HasData(seeds);
            }
        }

        public static Type getSetType<T>(this DbSet<T> dbSet) where T : class
        {
            return typeof(T);
        }

        public static void BuildEntites(this EntityTypeBuilder entityBuilder, Type modelType)
        {
            foreach (var tableColumn in modelType.GetProperties())
            {
                entityBuilder.SetPrimaryKey(tableColumn);
                entityBuilder.SetNonNullable(tableColumn);
                entityBuilder.SetIdentity(tableColumn);
                entityBuilder.SetColumnName(tableColumn);
            }
        }

        private static void SetPrimaryKey(this EntityTypeBuilder entityBuilder, PropertyInfo entityProperty)
        {
            string fieldName = entityProperty.Name;
            var attributes = entityProperty.CustomAttributes;

            if (attributes.Any(x => x.AttributeType == typeof(PrimaryKey)))
            {
                entityBuilder.HasKey(fieldName);
            }
        }

        private static void SetNonNullable(this EntityTypeBuilder entityBuilder, PropertyInfo entityProperty)
        {
            string fieldName = entityProperty.Name;
            var attributes = entityProperty.CustomAttributes;

            if (attributes.Any(x => x.AttributeType == typeof(NotNull)))
            {
                entityBuilder.Property(fieldName).IsRequired();
            }
        }

        private static void SetIdentity(this EntityTypeBuilder entityBuilder, PropertyInfo entityProperty)
        {
            string fieldName = entityProperty.Name;
            var attributes = entityProperty.CustomAttributes;

            if (attributes.Any(x => x.AttributeType == typeof(Identity)))
            {
                entityBuilder.Property(fieldName).ValueGeneratedOnAdd();
            }
        }

        private static void SetColumnName(this EntityTypeBuilder entityBuilder, PropertyInfo entityProperty)
        {
           string fieldName = entityProperty.Name;
            var attributes = entityProperty.CustomAttributes;

            if (attributes.Any(x => x.AttributeType == typeof(ColumnName)))
            {
                var nameInDatabse = attributes
                    .FirstOrDefault(x => x.AttributeType == typeof(ColumnName))
                    .ConstructorArguments
                    .FirstOrDefault()
                    .Value
                    .ToString();

                entityBuilder.Property(fieldName).HasColumnName(nameInDatabse);
            }
            else if(isBasePropertyType(entityProperty))
            {
                entityBuilder.Property(fieldName).HasColumnName(fieldName);
            }
        }

        private static bool isBasePropertyType(PropertyInfo property)
        {
            return property == typeof(string)
                || property == typeof(int)
                || property == typeof(decimal)
                || property == typeof(DateTime)
                || property == typeof(Guid)
                || property == typeof(float)
                || property == typeof(double);
        }
    }
}
