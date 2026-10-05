// HOW-TO: Return Rotated JPEG Image As FileResult In ASP.NET Core MVC (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main()
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output\\output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                image.Save(outputPath, new JpegOptions());
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
 * 1. When a web application needs to display user‑uploaded photos correctly oriented by rotating them 90° before sending the JPEG back to the browser.
 * 2. When an API endpoint must process an image, apply a rotation, and stream the resulting JPEG as a downloadable FileResult.
 * 3. When a content management system automatically corrects landscape images by rotating them and returns the edited file for preview in an MVC view.
 * 4. When a mobile backend service receives portrait pictures, rotates them to match device orientation, and returns the adjusted JPEG via ASP.NET Core FileResult.
 * 5. When a reporting tool generates charts as images, rotates them for layout purposes, and serves the final JPEG through an MVC controller action.
 */
