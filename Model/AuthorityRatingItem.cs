namespace InfinityWorks.TechTest.Controllers
{
    /// <summary>
    /// A single rating item.
    /// </summary>
    public class AuthorityRatingItem
    {
        /// <value>The name of the rating e.g. (One Star)</value>
        public string Name { get; private set; }

        /// <value>The distribution percentage of this rating</value>
        public double Value { get; private set; }

        public AuthorityRatingItem(string name, double value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
