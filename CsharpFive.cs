using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CsharpShowreel
{
    /// <summary>
    /// C# 5 new features:
    ///  - Async stuff
    ///  - Caller info stuff
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
            // TPL way instead of await
            var result = Task.Run(() => GetData()).Result;
        }

        public  void ShowCallerInfo([CallerMemberName] string callerName = null, 
            [CallerFilePath] string callerFilePath = null, 
            [CallerLineNumber] int callerLine=-1)
        {
            System.Console.WriteLine("Caller Name: {0}", callerName);
            System.Console.WriteLine("Caller FilePath: {0}", callerFilePath);
            System.Console.WriteLine("Caller Line number: {0}", callerLine);
        }

        public CsharpFive()
        {
            RunSynchronously1();
            RunSynchronously2();
            ShowCallerInfo();
        }
    }
}