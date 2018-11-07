using System.Threading.Tasks;

namespace Kritner.ExtensionMethods
{
    /// <summary>
    /// Extension Methods for <see cref="Task"/>
    /// </summary>
    public static class TaskExtensions
    {
        /// <summary>
        /// Can be used to fire off a Task and not await the reuslt.
        /// </summary>
        /// <param name="task"></param>
        public static void FireAndForget(this Task task) { }
    }
}
