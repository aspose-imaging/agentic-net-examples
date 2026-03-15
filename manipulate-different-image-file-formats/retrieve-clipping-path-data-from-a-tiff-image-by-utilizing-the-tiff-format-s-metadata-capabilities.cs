using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.PathResources;
using System;

class Program
{
    static void Main()
    {
        // Load the TIFF image using the provided load rule
        using (TiffImage tiff = (TiffImage)Image.Load("Sample.tif"))
        {
            // Access clipping paths stored in the active frame's PathResources
            foreach (PathResource path in tiff.ActiveFrame.PathResources)
            {
                // Output basic information about each clipping path
                Console.WriteLine($"Path Name : {path.Name}");
                Console.WriteLine($"Block Id  : {path.BlockId}");
                Console.WriteLine($"Records   : {path.Records?.Count ?? 0}");

                // Optionally list the type of each record in the path
                if (path.Records != null)
                {
                    foreach (var record in path.Records)
                    {
                        Console.WriteLine($"  Record Type: {record.GetType().Name}");
                    }
                }

                Console.WriteLine(); // Blank line between paths
            }
        }
    }
}