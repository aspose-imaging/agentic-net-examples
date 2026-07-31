using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage sourceImage = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 70,
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage apngImage = (ApngImage)Aspose.Imaging.Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
                {
                    int numOfFrames = 10;
                    apngImage.RemoveAllFrames();

                    for (int i = 0; i < numOfFrames; i++)
                    {
                        apngImage.AddFrame(sourceImage);
                    }

                    apngImage.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer wants to embed the Aspose.Imaging for .NET version into the APNG “Software” metadata field to trace which library generated the animated PNG during a CI/CD pipeline.
 * 2. When a graphics workflow requires recording the processing tool’s version in the APNG file so that downstream applications can verify compatibility before rendering.
 * 3. When an e‑learning platform creates animated PNG tutorials and needs to tag each file with the exact library version for future maintenance and support tickets.
 * 4. When a digital asset management system archives APNG assets and relies on the “Software” metadata to filter images processed by a specific version of Aspose.Imaging.
 * 5. When a QA team runs automated tests on image conversion scripts and uses the APNG “Software” field to confirm that the correct library build was used for each generated animation.
 */