using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.FileManagement;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class LoadTiffExample
{
    static void Main()
    {
        // Path to the source TIFF file
        string inputPath = "input.tif";

        // -----------------------------------------------------------------
        // Load TIFF using the TiffFrame constructor that accepts a file path
        // -----------------------------------------------------------------
        TiffFrame fileFrame = new TiffFrame(inputPath);

        // Create a TiffImage from the loaded frame
        using (TiffImage tiffFromFile = new TiffImage(fileFrame))
        {
            // Example: read image dimensions
            int width = tiffFromFile.Width;
            int height = tiffFromFile.Height;
            Console.WriteLine($"Loaded from file – Width: {width}, Height: {height}");

            // Save a copy to verify that the image was loaded correctly
            tiffFromFile.Save("copy_from_file.tif");
        }

        // -----------------------------------------------------------------
        // Load TIFF from a stream using native TIFF stream handling
        // -----------------------------------------------------------------
        using (FileStream stream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
        {
            // Wrap the .NET stream into Aspose.Imaging's StreamContainer
            StreamContainer container = new StreamContainer(stream);

            // Obtain a TiffStreamReader for the stream (LittleEndian used as example)
            TiffStreamReader reader = TiffStreamFactory.GetTiffReader(container, TiffByteOrder.LittleEndian);

            // The reader can be used for low‑level TIFF operations.
            // For high‑level image handling, create a TiffFrame directly from the stream.
            TiffFrame streamFrame = new TiffFrame(stream);

            using (TiffImage tiffFromStream = new TiffImage(streamFrame))
            {
                // Example: read image dimensions
                int width = tiffFromStream.Width;
                int height = tiffFromStream.Height;
                Console.WriteLine($"Loaded from stream – Width: {width}, Height: {height}");

                // Save a copy to verify that the image was loaded correctly
                tiffFromStream.Save("copy_from_stream.tif");
            }
        }
    }
}