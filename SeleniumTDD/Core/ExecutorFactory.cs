using System.Threading;

namespace SeleniumTDD.Core
{
    public class ExecutorFactory
    {
        private static ThreadLocal<IToolsFactory> EXECUTOR_POOL = new ThreadLocal<IToolsFactory>();

        public static IToolsFactory GetToolFactory()
        {
            return EXECUTOR_POOL.Value;
        }

        public static void RegisterToolFactory(IToolsFactory toolFactory)
        {
            EXECUTOR_POOL.Value = toolFactory;
        }

        public static void DeregisterToolFactory()
        {
            EXECUTOR_POOL.Dispose();
        }
    }
}
