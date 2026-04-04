using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input path and password
        string inputPath = "sample.jpg";
        string password = "mySecretPassword";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load JPEG image from a file stream
        using (FileStream stream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
        {
            using (Image image = Image.Load(stream))
            {
                // Cast to RasterImage to access IsDigitalSigned
                RasterImage raster = image as RasterImage;
                bool isSigned = false;

                if (raster != null)
                {
                    // Perform digital signature verification
                    isSigned = raster.IsDigitalSigned(password);
                }

                // Output verification result
                Console.WriteLine($"Digital signature verification: {(isSigned ? "Valid" : "Invalid")}");
            }
        }
    }
}