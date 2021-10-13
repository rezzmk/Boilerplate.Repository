namespace Boilerplate.Repository.DataStructures {
    public class ResultWithMetadata<T> where T : class {
        public T Result { get; }
        public PagingMetadata PagingMetadata { get; }

        public ResultWithMetadata(T result, PagingMetadata metadata) {
            Result = result;
            PagingMetadata = metadata;
        }
    }
}