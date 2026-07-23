using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output/result.txt";
        string password = "myPassword";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (unconditional)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access digital signature methods
                RasterImage rasterImage = image as RasterImage;
                if (rasterImage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a raster image.");
                    return;
                }

                // Analyze the confidence percentage of the embedded digital signature
                int confidence = rasterImage.AnalyzePercentageDigitalSignature(password);

                // Output the result to console
                Console.WriteLine($"Digital signature confidence: {confidence}%");

                // Also write the result to the output file
                File.WriteAllText(outputPath, $"Digital signature confidence: {confidence}%");
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
 * 1. When a legal document management system stores signed contracts as JPEG scans, a developer can use this code to verify the confidence level of the embedded digital signature before archiving the file.
 * 2. When a photo‑sharing platform needs to ensure that uploaded images contain a trusted watermark signature, the code can read the JPEG, apply the password, and report the signature confidence percentage.
 * 3. When a compliance audit tool processes marketing assets saved as JPEGs, it can call AnalyzePercentageDigitalSignature to confirm that each image meets the required signature integrity threshold.
 * 4. When an e‑commerce site generates product images with embedded digital signatures for anti‑counterfeit protection, the developer can run this snippet to programmatically assess the signature’s confidence score.
 * 5. When a forensic analysis application examines suspect JPEG files, it can load the image with Aspose.Imaging, supply the known password, and retrieve the digital signature confidence to aid in authenticity verification.
 */