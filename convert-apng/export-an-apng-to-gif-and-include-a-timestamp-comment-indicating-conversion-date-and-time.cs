// HOW-TO: Convert APNG to GIF with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.apng";
            string outputPath = "Output\\result.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new GifOptions());
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
 * 1. When you need to display an animated PNG on browsers that only support GIF, you can convert the APNG to a GIF using Aspose.Imaging in C#.
 * 2. When preparing assets for email newsletters that require GIF animation, you can programmatically transform APNG files to GIF format with C#.
 * 3. When a mobile app only accepts GIF images for animated stickers, you can use this code to convert APNG resources to GIF on the server side.
 * 4. When generating legacy reports that embed animated images, converting APNG to GIF ensures compatibility with older PDF viewers via C#.
 * 5. When automating a batch process that archives animated graphics, converting each APNG to a smaller GIF file simplifies storage and retrieval in .NET applications.
 */
