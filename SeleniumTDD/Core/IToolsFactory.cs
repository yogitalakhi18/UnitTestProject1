
namespace SeleniumTDD.Core
{
    public interface IToolsFactory
    {
        void CreateInstance();

        T GetInstance<T>();

        void CloseInstance();
    }
}
