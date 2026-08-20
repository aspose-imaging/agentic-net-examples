// HOW-TO: Convert Multiple BMP Images to SVG and Upload to Cloud in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input directory containing BMP files
            string inputDirectory = @"C:\Images\InputBmp";
            // Hardcoded output directory (could be a local staging folder before upload)
            string outputDirectory = @"C:\Images\OutputSvg";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Example list of BMP files to process
            string[] bmpFiles = new string[]
            {
                "image1.bmp",
                "image2.bmp",
                "image3.bmp"
            };

            foreach (var fileName in bmpFiles)
            {
                string inputPath = Path.Combine(inputDirectory, fileName);
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputFileName = Path.ChangeExtension(fileName, ".svg");
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare vector rasterization options based on the source image size
                    var vectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // Save as SVG using SvgOptions
                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = vectorRasterizationOptions,
                        Compress = false // No compression for plain SVG
                    };

                    image.Save(outputPath, svgOptions);
                }

                // Upload the generated SVG to a cloud storage bucket
                // Placeholder implementation – replace with actual SDK calls as needed
                CloudStorageClient.UploadFile(outputPath, "my-bucket-name");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

// Placeholder for a cloud storage client. Replace with actual implementation (e.g., AWS S3, Azure Blob, Google Cloud Storage).
static class CloudStorageClient
{
    public static void UploadFile(string localFilePath, string bucketName)
    {
        // Example pseudo-code:
        // var client = new CloudStorageServiceClient();
        // client.UploadObject(bucketName, Path.GetFileName(localFilePath), File.OpenRead(localFilePath));
        Console.WriteLine($"Uploaded '{localFilePath}' to bucket '{bucketName}'.");
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to batch‑convert legacy BMP graphics to scalable SVG files before publishing them on a website.
 * 2. When an application must generate vector versions of bitmap assets for responsive UI designs in C#.
 * 3. When you want to prepare image assets for a cloud‑based storage service that only accepts SVG format.
 * 4. When automating the migration of on‑premise BMP resources to a vector format for better compression and scalability.
 * 5. When integrating image processing into a CI/CD pipeline that transforms BMP files into SVGs for downstream services.
 */
