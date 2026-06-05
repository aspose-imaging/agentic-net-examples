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
            // Define output path (hard‑coded)
            string outputPath = @"C:\temp\output.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a FileCreateSource bound to the output file
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas (500x500)
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize Graphics for the image
                Graphics graphics = new Graphics(image);

                // Enable anti‑aliasing for smoother edges
                graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Optional: clear background to white
                graphics.Clear(Color.White);

                // Save the image (output is already bound to the file)
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
 * 1. When generating a PNG thumbnail with smooth vector shapes, a developer can create a blank image, initialize Graphics, and set SmoothingMode to AntiAlias to avoid jagged edges.
 * 2. When programmatically drawing a company logo onto a 500x500 canvas for a web banner, using Graphics with AntiAlias ensures the logo’s curves render cleanly.
 * 3. When exporting a diagram or flowchart to a high‑resolution PNG file, initializing Graphics and enabling anti‑aliasing produces professional‑grade line quality.
 * 4. When building a PDF‑to‑image conversion tool that rasterizes vector content into PNG, setting SmoothingMode to AntiAlias during drawing improves visual fidelity.
 * 5. When creating custom UI icons on the fly in a C# desktop application, using Graphics with AntiAlias on a newly created image prevents pixelated edges in the final PNG file.
 */