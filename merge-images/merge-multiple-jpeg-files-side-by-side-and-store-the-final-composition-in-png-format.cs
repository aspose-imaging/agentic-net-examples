using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        string[] inputPaths = new string[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };

        string outputPath = "output/merged.png";

        foreach (string path in inputPaths)
        {
            if (!System.IO.File.Exists(path))
            {
                System.Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        var sizes = new System.Collections.Generic.List<Aspose.Imaging.Size>();
        foreach (string path in inputPaths)
        {
            using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        int newWidth = 0;
        int newHeight = 0;
        foreach (var s in sizes)
        {
            newWidth += s.Width;
            if (s.Height > newHeight) newHeight = s.Height;
        }

        System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(outputPath));

        Aspose.Imaging.Sources.FileCreateSource source = new Aspose.Imaging.Sources.FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions() { Source = source };
        using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(pngOptions, newWidth, newHeight))
        {
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
                {
                    var bounds = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            canvas.Save();
        }
    }
}