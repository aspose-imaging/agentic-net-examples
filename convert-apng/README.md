# Convert APNG – Aspose.Imaging for .NET  

Create, edit, and export **APNG animation** files directly from C#. These samples show how to generate an **animated PNG** with custom frame delays, loop counts, and more using the Aspose.Imaging .NET library – the simplest way to **create APNG** in a .NET application.

## What's in This Category
- Load a single‑page PNG and turn it into an animated APNG with a uniform 100 ms frame delay.  
- Load a PNG image and build an APNG with per‑frame custom delays.  
- Assemble multiple PNG files into one APNG animation and specify a custom loop count.  
- Adjust existing APNG frames (e.g., replace a frame, change delay) before saving.  
- Export the resulting APNG to a stream or file for further processing.

## Quick Start  

```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

// Load a PNG, add two frames with different delays, and save as APNG
using (var png = Image.Load(@"input.png"))
{
    var apng = new ApngImage(png.Width, png.Height);
    apng.Frames.Add(new ApngFrame(png, delay: 50));   // 50 ms
    apng.Frames.Add(new ApngFrame(png, delay: 150));  // 150 ms

    var options = new ApngOptions { LoopCount = 0 }; // infinite loop
    apng.Save(@"output.apng", options);
}
```

The snippet demonstrates the most common operation: **creating an animated PNG in C#** with custom frame delays.

## All Examples  

| Example | Description |
|---|---|
| [load-a-png-image-and-create-an-animated-apng-with-custom-frame-delays.cs](./load-a-png-image-and-create-an-animated-apng-with-custom-frame-delays.cs) | Load a PNG image and create an animated APNG with custom frame delays. |
| [generate-an-apng-from-a-single-page-png-specifying-a-100-ms-delay-for-each-frame.cs](./generate-an-apng-from-a-single-page-png-specifying-a-100-ms-delay-for-each-frame.cs) | Generate an APNG from a single‑page PNG, specifying a 100 ms delay for each frame. |
| [load-multiple-png-images-and-assemble-them-into-a-single-apng-animation-with-custom-loop-count.cs](./load-multiple-png-images-and-assemble-them-into-a-single-apng-animation-with-custom-loop-count.cs) | Load multiple PNG images and assemble them into a single APNG animation with a custom loop count. |
| [modify-apng-frame-delay-and-save.cs](./modify-apng-frame-delay-and-save.cs) | Change the delay of existing frames in an APNG and re‑export the animation. |
| [replace-apng-frame-and-update-loop-count.cs](./replace-apng-frame-and-update-loop-count.cs) | Replace a specific frame in an APNG and set a new loop count before saving. |

## Requirements  

- **Aspose.Imaging for .NET** – install via NuGet: `Install-Package Aspose.Imaging`  
- **.NET 9** or later  

## Back to the main repository  

[← Root README](../README.md)