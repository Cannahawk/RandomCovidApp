namespace FooBackBar.Controllers.Base
{
    public interface BaseDto <Entity, Dto> where Entity : Models.Entity 
        where Dto : BaseDto<Entity, Dto>
    {
        Dto FromEntity(Entity entity);
    }
}
