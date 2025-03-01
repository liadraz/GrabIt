namespace GrabIt.Infrastructure
{
    public class GrabItDBTests
    {
        [Fact]
        public void TestConnectionToDB()
        {
            GrabItDB db = new GrabItDB();

            Assert.NotNull(db);
            Assert.True(db.OpenConnection());
            Assert.True(db.CloseConnection());
        }
    }
}
