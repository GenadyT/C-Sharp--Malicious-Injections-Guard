using System.Text;

namespace CheckMalicious
{
    public abstract class MaliciousUmbrel<T>
    {
        // -- place the class object here --
        protected T entity;
        private bool isMalicious;

        public MaliciousUmbrel(T entity)
        {
            this.entity = entity;
            this.isMalicious = MaliciousState.IsMalicious;  // !!!
        }

        public abstract MaliciousInfo ReportMalicious();
    }
}
