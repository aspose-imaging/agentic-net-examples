using System;
using System.Collections.Generic;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Get the bitmask of all registered image loading formats
        FileFormat registered = ImageLoadersRegistry.RegisteredFormats;

        // Prepare a list to hold the names of supported raster formats
        List<string> supportedFormats = new List<string>();

        // Iterate over all defined FileFormat enum values
        foreach (FileFormat format in Enum.GetValues(typeof(FileFormat)))
        {
            // Skip the special values that are not actual formats
            if (format == FileFormat.Unknown || format == FileFormat.Custom)
                continue;

            // Check if the current format flag is present in the registered bitmask
            if ((registered & format) != 0)
            {
                // Add the format name to the result list
                supportedFormats.Add(format.ToString());
            }
        }

        // Output the supported input formats for raster image conversion
        Console.WriteLine("Supported raster input formats:");
        foreach (string name in supportedFormats)
        {
            Console.WriteLine("- " + name);
        }
    }
}