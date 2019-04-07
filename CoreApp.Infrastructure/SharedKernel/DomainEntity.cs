namespace CoreApp.Infrastructure.SharedKernel
{
    public class DomainEntity<T>
    {
        public T Id { get; set; }

        /// <summary>
        /// True if domain identity existed
        /// </summary>
        /// <returns></returns>
        public bool IsTrasient()
        {
            return Id.Equals(default(T));
        }
    }
}