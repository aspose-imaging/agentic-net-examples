// HOW-TO: Create 1024x768 BMP Image and Save to File in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.bmp");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);
            using (Image image = Image.Create(options, 1024, 768))
            {
                image.Save();
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
 * 1. When you need to generate a blank BMP canvas of a specific resolution for a reporting tool that requires a 1024x768 bitmap file.
 * 2. When an application must programmatically create a BMP placeholder image for a document generation workflow without loading an existing picture.
 * 3. When you want to produce a BMP file on the server side for legacy systems that only accept uncompressed bitmap formats.
 * 4. When a desktop utility needs to export a custom-sized bitmap for printing or further processing using Aspose.Imaging in C#.
 * 5. When you are automating the creation of a BMP thumbnail of exact dimensions to embed in a Windows application’s resources.
 */
