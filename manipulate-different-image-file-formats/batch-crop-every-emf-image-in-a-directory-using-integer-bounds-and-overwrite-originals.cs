using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try-catch to handle unexpected errors gracefully
        try
        {
            // Hard‑coded input directory containing EMF files
            string inputDirectory = @"C:\Images\Emf";

            // Define integer crop bounds (example: crop 10 pixels from each side)
            int cropX = 10;      // left offset
            int cropY = 10;      // top offset
            int cropWidth = 200; // width of the cropped area
            int cropHeight = 150; // height of the cropped area

            // Get all EMF files in the directory
            string[] emfFiles = Directory.GetFiles(inputDirectory, "*.emf");

            foreach (string inputPath in emfFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Output path is the same as input path (overwrite)
                string outputPath = inputPath;

                // Ensure the output directory exists (unconditional call as required)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EMF image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to EmfImage to access vector‑specific operations
                    EmfImage emfImage = (EmfImage)image;

                    // Perform the crop using integer bounds
                    emfImage.Crop(new Rectangle(cropX, cropY, cropWidth, cropHeight));

                    // Save the modified image back to the original location
                    emfImage.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            // Output any runtime error without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a company needs to automatically remove unwanted margins from a large collection of vector‑based EMF logos before embedding them into a corporate brochure.
 * 2. When a GIS team must trim excess whitespace from thousands of EMF map overlays to ensure they align correctly in a mapping application.
 * 3. When a software vendor wants to standardize the size of EMF icons by cropping each file to a fixed rectangle before packaging them into a UI toolkit.
 * 4. When an e‑learning platform processes uploaded EMF diagrams and needs to crop a consistent area to hide confidential information while preserving the original files.
 * 5. When a print shop prepares EMF artwork for batch printing and must crop each image to the exact printable area, overwriting the originals to simplify file management.
 */