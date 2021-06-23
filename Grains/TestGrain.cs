using System.Threading.Tasks;
using Orleans;

namespace Sarmady.Orleans.Grains
{

    public interface ITestGrain : IGrainWithStringKey
    {
        Task<string> SayHelloGrainTest(string name);
        Task<string> ClearState();
    }

    public class TestGrain : Grain<TestGrainState>, ITestGrain
    {
        public async Task<string> SayHelloGrainTest(string name)
        {
            var count = State.InvocationCount++;
            await WriteStateAsync();

            return $"Hello {name}, from {this.GetPrimaryKeyString()}, Invoked = {count} times.";
        }

        public async Task<string> ClearState()
        {
            await ClearStateAsync();
            return "State has been cleared.";
        }
    }

   public class TestGrainState
    {
        public int InvocationCount { get; set; }
    }
}
