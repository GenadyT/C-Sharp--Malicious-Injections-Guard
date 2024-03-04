namespace CheckMalicious
{
    public abstract class EntityUmbrel<T>
    {
        // -- place the class object here --
        private T entity;

        public EntityUmbrel(T entity)
        {
            this.entity = entity;
        }

        public abstract MaliciousInfo MaliciousInfo();
    }
}
