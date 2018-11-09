namespace InfinityWorks.TechTest.Controllers
{
    public class Authority {

        public int Id { get; private set; }
        public string Name { get; private set; }

        public Authority(int id, string name) {
            this.Id = id;
            this.Name = name;
        }

        public override string ToString() {
            return "Authority{" +
                    "id=" + this.Id +
                    ", name='" + this.Name + '\'' +
                    '}';
        }
    }
}