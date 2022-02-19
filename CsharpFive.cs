using System.Threading.Tasks;

namespace CsharpShowreel
{
    /// <summary>
    /// C# 5 new features:
    ///   - Async stuff
    /// </summary>
    public class CsharpFive
    {
        public async System.Threading.Tasks.Task<object> QueryDb()
        {
            return await System.Threading.Tasks.Task.FromResult<int>(1); // FromResult<int>(1)
        }

        public async System.Threading.Tasks.Task<object> GetData()
        {
            var result = await QueryDb();
            return result;
        }

        public void RunSynchronously1()
        {
            var task = GetData(); 
            task.Wait();
        }

        public void RunSynchronously2()
        {
            var result = Task.Run(() => GetData()).Result;
        }

        public CsharpFive()
        {
            RunSynchronously1();
            RunSynchronously2();
        }
    }
}