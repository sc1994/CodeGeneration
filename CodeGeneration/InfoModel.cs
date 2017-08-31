namespace CodeGeneration
{
    public class InfoModel
    {
        public static Info Info = "../../Info.json".GetFileText().ToObjectByJson<Info>();
    }
}
