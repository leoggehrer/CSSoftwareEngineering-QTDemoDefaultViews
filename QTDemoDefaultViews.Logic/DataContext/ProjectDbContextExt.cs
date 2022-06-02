namespace QTDemoDefaultViews.Logic.DataContext
{
    /// <summary>
    /// This part is for the domain specific extensions
    /// </summary>
    partial class ProjectDbContext
    {
        public DbSet<Entities.Person>? PersonSet { get; set; }

        partial void GetDbSet<E>(ref DbSet<E>? dbSet, ref bool handled) where E : Entities.IdentityEntity
        {
            if (typeof(E) == typeof(Entities.Person))
            {
                handled = true;
                dbSet = PersonSet as DbSet<E>;
            }
        }
    }
}
