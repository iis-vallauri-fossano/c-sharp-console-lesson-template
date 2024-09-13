namespace tests
{
    public class IOTests : IDisposable
    {
        private StringWriter _stdOutMock;
        private TextWriter _stdOut;

        public IOTests()
        {
            this._stdOut = Console.Out;
            this._stdOutMock = new StringWriter();

            Console.SetOut(_stdOutMock);
        }

        [Fact(DisplayName="Testing the default prints A and B")]
        public void Test1()
        {
            // Write test code here with parameters...
            string[] args = { "" };
            lesson.Program.Main(args);
            this._stdOutMock.Flush();

            var actualOutputLines = this._stdOutMock.ToString().Trim().Split(this._stdOutMock.NewLine);
            string[] expectedOutputLines = { "A", "B" };

            Xunit.Assert.Equal(expectedOutputLines, actualOutputLines);
        }

        [Fact(DisplayName = "This is another test")]
        public void Test2()
        {
            // Write test code here with parameters...
            string[] args = { "2" };
            lesson.Program.Main(args);
        }

        public void Dispose()
        {
            Console.SetOut(this._stdOut);

            this._stdOutMock.Dispose();
        }
    }
}