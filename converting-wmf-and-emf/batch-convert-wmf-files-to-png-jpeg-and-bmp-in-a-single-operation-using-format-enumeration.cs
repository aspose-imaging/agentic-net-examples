// HOW-TO: Batch Convert WMF Files to PNG JPEG and BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace WmfBatchConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputDirectory = @"C:\InputWmf";
                string outputDirectory = @"C:\OutputImages";

                string[] wmfFiles = Directory.GetFiles(inputDirectory, "*.wmf");

                foreach (string wmfPath in wmfFiles)
                {
                    if (!File.Exists(wmfPath))
                    {
                        Console.Error.WriteLine($"File not found: {wmfPath}");
                        return;
                    }

                    using (Image image = Image.Load(wmfPath))
                    {
                        foreach (OutputFormat format in Enum.GetValues(typeof(OutputFormat)))
                        {
                            string extension = format.ToString().ToLower();
                            string outputPath = Path.Combine(outputDirectory, $"{Path.GetFileNameWithoutExtension(wmfPath)}.{extension}");

                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            switch (format)
                            {
                                case OutputFormat.Png:
                                    var pngOptions = new PngOptions();
                                    image.Save(outputPath, pngOptions);
                                    break;
                                case OutputFormat.Jpeg:
                                    var jpegOptions = new JpegOptions();
                                    image.Save(outputPath, jpegOptions);
                                    break;
                                case OutputFormat.Bmp:
                                    var bmpOptions = new BmpOptions();
                                    image.Save(outputPath, bmpOptions);
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }

        enum OutputFormat
        {
            Png,
            Jpeg,
            Bmp
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a legacy Windows application generates vector WMF icons that must be displayed on web pages, a developer can batch convert them to PNG, JPEG, and BMP for browser compatibility.
 * 2. When preparing print‑ready assets, a designer can use this code to transform multiple WMF diagrams into high‑resolution BMP files alongside web‑friendly PNG and JPEG versions in a single run.
 * 3. When migrating an old document repository to a modern content management system, a developer can automatically convert all stored WMF drawings to the required image formats without writing separate conversion scripts.
 * 4. When building a reporting tool that exports charts as WMF and needs to provide downloadable image options, this batch conversion simplifies generating PNG, JPEG, and BMP files for end users.
 * 5. When implementing a CI/CD pipeline that validates visual assets, the code can quickly verify that every WMF file in a source folder is correctly rendered into the three common raster formats before deployment.
 */
