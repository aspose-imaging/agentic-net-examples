using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.eps";
            string outputPath = "output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                // Resize to 150x150 pixels (thumbnail)
                image.Resize(150, 150, ResizeType.NearestNeighbourResample);

                // Save as JPEG
                var jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
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
 * 1. When a web application needs to display preview thumbnails of user‑uploaded EPS vector files as small JPEG images (150 × 150 px) in a gallery view.
 * 2. When an e‑commerce platform must generate product‑listing images from designer‑provided EPS logos and store them as compressed JPEG thumbnails for faster page loads.
 * 3. When a document‑management system automatically creates searchable preview icons for EPS drawings by converting them to 150 px JPEG thumbnails during file ingestion.
 * 4. When a desktop utility converts batch EPS artwork into uniform 150 × 150 pixel JPEG thumbnails for quick visual selection in a file‑explorer interface.
 * 5. When a reporting tool needs to embed small JPEG previews of EPS charts into PDF reports, requiring the EPS to be resized to a 150 px thumbnail first.
 */