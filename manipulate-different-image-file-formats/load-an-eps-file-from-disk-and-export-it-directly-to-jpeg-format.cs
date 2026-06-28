using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input.eps";
            string outputPath = "output/output.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image and save it as JPEG
            using (Image image = Image.Load(inputPath))
            {
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
 * 1. When a web application needs to display a thumbnail of an EPS logo, a developer can use this C# code to load the EPS file and save it as a JPEG image for fast browser rendering.
 * 2. When a document management system must generate preview images for stored EPS artwork, the code can convert each EPS into a JPEG using Aspose.Imaging’s Image.Load and Image.Save methods.
 * 3. When a print shop wants to provide clients with quick JPEG proofs of their EPS designs, the developer can automate the conversion with this C# snippet to create JPEG files in a specified output folder.
 * 4. When an automated email report includes vector diagrams originally saved as EPS, the code enables the developer to render those diagrams as JPEGs that embed correctly in the email body.
 * 5. When a cloud service receives user‑uploaded EPS files and stores them in a database, the developer can use this code to transform the EPS into a JPEG format suitable for thumbnails and quick retrieval.
 */