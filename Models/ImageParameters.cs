namespace Dual_Image_Finder.Models
{
    class ImageParameters
    {
        public MainForm MainForm { get; }
        public string FolderPath { get; set; }
        public int ComparisonRate { get; set; }
        public bool Auto { get; set; }
        public bool DeleteRequire { get; set; }
        public bool KeeplaLargerSize { get; set; }
        public bool UseMatrice { get; set; }

        public ImageParameters(MainForm mainForm, string folderPath, int comparisonRate, bool auto, bool deleteRequire, bool keeplaLargerSize, bool useMatrice)
        {
            this.MainForm = mainForm;
            this.FolderPath = folderPath;
            this.ComparisonRate = comparisonRate;
            this.Auto = auto;
            this.DeleteRequire = deleteRequire;
            this.KeeplaLargerSize = keeplaLargerSize;
            this.UseMatrice = useMatrice;
        }

    }
}
