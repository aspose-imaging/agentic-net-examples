using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        string inputPath = "input.emf";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        using (Image image = Image.Load(inputPath))
        {
            IMultipageImage multipage = image as IMultipageImage;
            int pageCount = (multipage != null && multipage.PageCount > 0) ? multipage.PageCount : 1;

            for (int i = 0; i < pageCount; i++)
            {
                string outputPath = $"output{Path.DirectorySeparatorChar}page_{i + 1}.png";
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                PngOptions pngOptions = new PngOptions
                {
                    ResolutionSettings = new ResolutionSetting(300, 300),
                    MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1)),
                    VectorRasterizationOptions = new EmfRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Color.White
                    }
                };

                image.Save(outputPath, pngOptions);
            }
        }
    }
}