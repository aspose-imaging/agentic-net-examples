using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage image = (EpsImage)Aspose.Imaging.Image.Load(inputPath))
            {
                int newWidth = (int)(image.Width * 1.5);
                int newHeight = (int)(image.Height * 1.5);

                image.Resize(newWidth, newHeight, Aspose.Imaging.ResizeType.LanczosResample);

                JpegOptions jpegOptions = new JpegOptions();
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
 * 1. When a developer needs to generate a larger, high‑resolution preview of a vector EPS logo for a web thumbnail by scaling it 1.5× and saving as a JPEG.
 * 2. When an e‑commerce platform must convert product artwork stored as EPS files into high‑quality JPEG images with a custom scaling factor for better display on high‑DPI screens.
 * 3. When a print‑to‑digital workflow requires up‑scaling EPS page layouts before exporting them as JPEGs for client review.
 * 4. When a mobile app backend processes uploaded EPS graphics, enlarges them by 150 % using Lanczos resampling, and stores the result as a JPEG for fast loading.
 * 5. When a document management system automatically creates JPEG previews of EPS files with a 1.5× size increase to improve visual clarity in search results.
 */