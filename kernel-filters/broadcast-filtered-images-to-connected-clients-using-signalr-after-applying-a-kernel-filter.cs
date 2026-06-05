using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));
                raster.Save(outputPath);
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
 * 1. When a web application needs to apply a Gaussian blur to user‑uploaded PNG files and instantly push the processed images to all connected browsers via SignalR.
 * 2. When a live‑streaming dashboard must transform incoming screenshots with a kernel filter and broadcast the updated visuals to monitoring clients in real time.
 * 3. When an e‑learning platform wants to anonymize sensitive details in uploaded diagrams by blurring them and then deliver the sanitized images to students through a SignalR hub.
 * 4. When a collaborative design tool requires applying a custom blur effect to shared assets and synchronizing the changes across multiple editors using C# and SignalR.
 * 5. When a security system processes captured camera frames with a Gaussian blur for privacy compliance and immediately sends the filtered frames to a control‑room client application via SignalR.
 */