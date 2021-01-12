namespace FooBackBar.Controllers.Base
{
    public interface BaseRequestModel<Entity>
    {
        public Entity ToEntity();
    }
}
