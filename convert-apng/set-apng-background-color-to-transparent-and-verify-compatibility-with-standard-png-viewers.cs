// HOW-TO: Set APNG Background Color to Transparent and Save in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input/input.apng";
        string outputPath = "output/output.apng";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (ApngImage apng = (ApngImage)Aspose.Imaging.Image.Load(inputPath))
            {
                apng.BackgroundColor = Aspose.Imaging.Color.Transparent;

                ApngOptions options = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                apng.Save(outputPath, options);
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
 * 1. When you need to make an existing APNG file have a transparent background so it can be embedded on a website without showing a solid color block, using C# and Aspose.Imaging.
 * 2. When converting game sprite animations stored as APNGs to transparent backgrounds to allow them to overlay on different game scenes, using Aspose.Imaging in a .NET application.
 * 3. When preparing marketing assets such as animated banners in APNG format that must appear transparent in email clients, and you want to set the background programmatically with C#.
 * 4. When generating APNG thumbnails for a photo gallery and need the background to be transparent to match the gallery’s dark or light theme, using Aspose.Imaging’s BackgroundColor property.
 * 5. When verifying that an APNG saved with a transparent background is displayed correctly in standard PNG viewers and browsers, by loading, modifying, and saving the file with Aspose.Imaging in C#.
 */
