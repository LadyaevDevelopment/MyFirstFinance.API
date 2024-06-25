namespace Data.Production.Tests.Support
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class TestAsyncEnumerator<T>(IEnumerator<T> enumerator) : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> enumerator = enumerator;

        public T Current => this.enumerator.Current;

        public ValueTask DisposeAsync()
        {
            return new ValueTask(Task.Run(() => this.enumerator.Dispose()));
        }

        public ValueTask<bool> MoveNextAsync()
        {
            return new ValueTask<bool>(this.enumerator.MoveNext());
        }
    }
}