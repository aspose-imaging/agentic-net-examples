using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Path to the JPEG image (hard‑coded as required)
        string inputPath = "input.jpg";
        // Password used for digital signature verification
        string password = "myPassword";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the JPEG image from a file stream
            using (FileStream stream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                // Aspose.Imaging automatically detects the format from the stream
                using (Image image = Image.Load(stream))
                {
                    // Cast to RasterImage to access IsDigitalSigned
                    RasterImage raster = image as RasterImage;
                    if (raster == null)
                    {
                        Console.Error.WriteLine("The loaded image is not a raster image.");
                        return;
                    }

                    // Perform digital signature verification
                    bool isSigned = raster.IsDigitalSigned(password);

                    // Output the verification result
                    Console.WriteLine(isSigned
                        ? "The image is digitally signed."
                        : "The image is NOT digitally signed.");
                }
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
 * 1. When a developer needs to ensure that a JPEG file uploaded through a web API has not been tampered with, they can load the image from a stream and verify its digital signature with a password using Aspose.Imaging.
 * 2. When integrating a document management system that stores signed JPEG scans, the code can be used to read each image from storage and confirm the signature before allowing access.
 * 3. When building a desktop application that processes confidential photos, the developer can employ this snippet to open the JPEG via a FileStream and check the digital signature to enforce security policies.
 * 4. When automating a batch job that validates a collection of JPEG assets delivered by a third‑party vendor, the program can iterate over the files, load them as images, and verify their signatures with the provided password.
 * 5. When creating a forensic tool that audits image authenticity, the code demonstrates how to detect a digitally signed JPEG and output the verification result to the console for further analysis.
 */