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
            // Hard‑coded input and output file paths
            string inputPath = "input.eps";
            string outputPath = "output/preview.jpg";

            // Verify that the input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Retrieve the best available preview image
                Image preview = epsImage.GetPreviewImage();

                if (preview == null)
                {
                    Console.Error.WriteLine("No preview image found in the EPS file.");
                    return;
                }

                // Save the preview as a JPEG file
                var jpegOptions = new JpegOptions();
                preview.Save(outputPath, jpegOptions);
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
 * 1. When a web application needs to display a quick thumbnail of a vector EPS artwork without rendering the full file, a developer can extract the low‑resolution preview and save it as a JPEG for fast loading.
 * 2. When generating email newsletters that include product designs stored as EPS, a developer can use this code to create a JPEG preview that email clients can render.
 * 3. When building a document management system that indexes graphic assets, a developer can extract the EPS preview image and store it as a JPEG to provide visual search results.
 * 4. When converting legacy EPS files for mobile apps, a developer can generate low‑resolution JPEG previews to reduce bandwidth and improve performance on smartphones.
 * 5. When automating batch processing of print‑ready EPS files, a developer can create JPEG thumbnails for each file to preview the content in a Windows Explorer‑style gallery.
 */