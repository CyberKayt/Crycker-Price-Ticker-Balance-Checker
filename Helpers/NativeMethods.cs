namespace DaddyRecoveryBuilder.Helpers
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    [SuppressUnmanagedCodeSecurity()]
    internal static class NativeMethods
    {
        #region Для анимации
        [DllImport("user32.dll")]
        public static extern bool AnimateWindow(IntPtr hWnd, int time, Enums.AnimateWindowFlags flags);

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        public extern static int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);
        #endregion

        #region Для замены свойства файла и иконки приложения
        /// <summary>
        /// VS_VERSION signature.
        /// </summary>
        internal const uint VS_FFI_SIGNATURE = 0xFEEF04BD;
        /// <summary>
        /// VS_VERSION structure version.
        /// </summary>
        internal const uint VS_FFI_STRUCVERSION = 0x00010000;
        /// <summary>
        /// VS_VERSION file flags mask.
        /// </summary>
        internal const uint VS_FFI_FILEFLAGSMASK = 0x0000003F;
        /// <summary>
        /// If this value is used, the system maps the file into the calling process's virtual address space as if it were a data file.
        /// </summary>
        internal const uint LOAD_LIBRARY_AS_DATAFILE = 0x00000002;
        /// <summary>
        /// If this value is used, and the executable module is a DLL, the system does not call DllMain for process and thread initialization and termination.
        /// </summary>
        internal const uint DONT_RESOLVE_DLL_REFERENCES = 0x00000001;
        /// <summary>
        /// If this value is used and lpFileName specifies an absolute path, the system uses the alternate file search strategy.
        /// </summary>
        internal const uint LOAD_WITH_ALTERED_SEARCH_PATH = 0x00000008;
        /// <summary>
        /// If this value is used, the system does not perform automatic trust comparisons on the DLL or its dependents when they are loaded.
        /// </summary>
        internal const uint LOAD_IGNORE_CODE_AUTHZ_LEVEL = 0x00000010;
        /// <summary>
        /// Neutral primary language ID.
        /// </summary>
        public const ushort LANG_NEUTRAL = 0;
        /// <summary>
        /// US-English primary language ID.
        /// </summary>
        public const ushort LANG_ENGLISH = 9;
        /// <summary>
        /// Neutral sublanguage ID.
        /// </summary>
        public const ushort SUBLANG_NEUTRAL = 0;
        /// <summary>
        /// US-English sublanguage ID.
        /// </summary>
        public const ushort SUBLANG_ENGLISH_US = 1;
        /// <summary>
        /// CREATEPROCESS_MANIFEST_RESOURCE_ID is used primarily for EXEs. If an executable has a resource of type RT_MANIFEST, 
        /// ID CREATEPROCESS_MANIFEST_RESOURCE_ID, Windows will create a process default activation context for the process. 
        /// The process default activation context will be used by all components running in the process. 
        /// CREATEPROCESS_MANIFEST_RESOURCE_ID can also used by DLLs. When Windows probe for dependencies, if the dll has 
        /// a resource of type RT_MANIFEST, ID CREATEPROCESS_MANIFEST_RESOURCE_ID, Windows will use that manifest as the 
        /// dependency. 
        /// </summary>
        public const ushort CREATEPROCESS_MANIFEST_RESOURCE_ID = 1;
        /// <summary>
        /// ISOLATIONAWARE_MANIFEST_RESOURCE_ID is used primarily for DLLs. It should be used if the dll wants private 
        /// dependencies other than the process default. For example, if an dll depends on comctl32.dll version 6.0.0.0. 
        /// It should have a resource of type RT_MANIFEST, ID ISOLATIONAWARE_MANIFEST_RESOURCE_ID to depend on comctl32.dll 
        /// version 6.0.0.0, so that even if the process executable wants comctl32.dll version 5.1, the dll itself will still 
        /// use the right version of comctl32.dll. 
        /// </summary>
        public const ushort ISOLATIONAWARE_MANIFEST_RESOURCE_ID = 2;
        /// <summary>
        /// When ISOLATION_AWARE_ENABLED is defined, Windows re-defines certain APIs. For example LoadLibraryExW 
        /// is redefined to IsolationAwareLoadLibraryExW. 
        /// </summary>
        public const ushort ISOLATIONAWARE_NOSTATICIMPORT_MANIFEST_RESOURCE_ID = 3;
        /// <summary>
        /// An application-defined callback function used with the EnumResourceTypes and EnumResourceTypesEx functions.
        /// </summary>
        /// <param name="hModule">The handle to the module whose executable file contains the resources for which the types are to be enumerated.</param>
        /// <param name="lpszType">Pointer to a null-terminated string specifying the type name of the resource for which the type is being enumerated.</param>
        /// <param name="lParam">Specifies the application-defined parameter passed to the EnumResourceTypes or EnumResourceTypesEx function. </param>
        /// <returns>Returns TRUE if successful; otherwise, FALSE.</returns>
        internal delegate bool EnumResourceTypesDelegate(IntPtr hModule, IntPtr lpszType, IntPtr lParam);
        /// <summary>
        /// An application-defined callback function used with the EnumResourceNames and EnumResourceNamesEx functions.
        /// </summary>
        /// <param name="hModule">The handle to the module whose executable file contains the resources that are being enumerated.</param>
        /// <param name="lpszType">Pointer to a null-terminated string specifying the type of resource that is being enumerated.</param>
        /// <param name="lpszName">Specifies the name of a resource of the type being enumerated.</param>
        /// <param name="lParam">Specifies the application-defined parameter passed to the EnumResourceNames or EnumResourceNamesEx function.</param>
        /// <returns>Returns TRUE if the function succeeds or FALSE if the function does not find a resource of the type specified, or if the function fails for another reason.</returns>
        internal delegate bool EnumResourceNamesDelegate(IntPtr hModule, IntPtr lpszType, IntPtr lpszName, IntPtr lParam);
        /// <summary>
        /// An application-defined callback function used with the EnumResourceLanguages and EnumResourceLanguagesEx functions.
        /// </summary>
        /// <param name="hModule">The handle to the module whose executable file contains the resources for which the languages are being enumerated.</param>
        /// <param name="lpszType">Pointer to a null-terminated string specifying the type name of the resource for which the language is being enumerated.</param>
        /// <param name="lpszName">Pointer to a null-terminated string specifying the name of the resource for which the language is being enumerated.</param>
        /// <param name="wIDLanguage">Specifies the language identifier for the resource for which the language is being enumerated.</param>
        /// <param name="lParam">Specifies the application-defined parameter passed to the EnumResourceLanguages or EnumResourceLanguagesEx function.</param>
        /// <returns>Returns TRUE if successful or FALSE otherwise.</returns>
        internal delegate bool EnumResourceLanguagesDelegate(IntPtr hModule, IntPtr lpszType, IntPtr lpszName, ushort wIDLanguage, IntPtr lParam);

        /// <summary>
        /// Retrieve a handle to a device context (DC) for the client area of a specified window or for the entire screen. 
        /// </summary>
        /// <param name="hWnd">A handle to the window whose DC is to be retrieved. If this value is NULL, GetDC retrieves the DC for the entire screen.</param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the DC for the specified window's client area. 
        /// If the function fails, the return value is NULL.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("kernel32")]
        public static extern bool UpdateResource(IntPtr hUpdate, IntPtr type, IntPtr name, short language,
        [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] byte[] data, int dataSize);

        /// <summary>
        /// Releases a device context (DC), freeing it for use by other applications.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose DC is to be released.</param>
        /// <param name="hDC">A handle to the DC to be released.</param>
        /// <returns>
        /// The return value indicates whether the DC was released. If the DC was released, the return value is 1.
        /// If the DC was not released, the return value is zero.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

        /// <summary>
        /// Destroys an icon and frees any memory the icon occupied.
        /// </summary>
        /// <param name="hIcon">Handle to the icon to be destroyed.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern int DestroyIcon(IntPtr hIcon);

        /// <summary>
        /// Creates an icon or cursor from an ICONINFO structure.
        /// </summary>
        /// <param name="piconInfo">Pointer to an ICONINFO structure the function uses to create the icon or cursor.</param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the icon or cursor that is created.
        /// If the function fails, the return value is NULL.
        /// </returns>
        [DllImport("user32,dll", SetLastError = true)]
        internal static extern IntPtr CreateIconIndirect(ref Structures.ICONINFO piconInfo);

        /// <summary>
        /// Creates a memory device context (DC) compatible with the specified device.
        /// </summary>
        /// <param name="hdc">Handle to an existing device context.</param>
        /// <returns>
        /// The handle to a memory device context indicates success.
        /// NULL indicates failure.
        /// </returns>
        [DllImport("gdi32.dll", SetLastError = true)]
        internal static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpDriverName">Specifies either DISPLAY or the name of a specific display device or the name of a print provider, which is usually WINSPOOL.</param>
        /// <param name="lpDeviceName">Specifies the name of the specific output device being used, as shown by the Print Manager (for example, Epson FX-80).</param>
        /// <param name="lpOutput">This parameter is ignored and should be set to NULL. It is provided only for compatibility with 16-bit Windows.</param>
        /// <param name="lpInitData">A pointer to a DEVMODE structure containing device-specific initialization data for the device driver.</param>
        /// <returns></returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern IntPtr CreateDC(string lpDriverName, string lpDeviceName, string lpOutput, IntPtr lpInitData);

        /// <summary>
        /// Creates a bitmap compatible with the device that is associated with the specified device context.
        /// </summary>
        /// <param name="hdc">A handle to a device context.</param>
        /// <param name="nWidth">The bitmap width, in pixels.</param>
        /// <param name="nHeight">The bitmap height, in pixels.</param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the compatible bitmap (DDB).
        /// If the function fails, the return value is NULL.
        /// </returns>
        [DllImport("gdi32.dll", SetLastError = true)]
        internal static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

        /// <summary>
        /// Selects an object into a specified device context. The new object replaces the previous object of the same type. 
        /// </summary>
        /// <param name="hdc">Handle to the device context.</param>
        /// <param name="hgdiobj">Handle to the object to be selected.</param>
        /// <returns>
        /// If the selected object is not a region, the handle of the object being replaced indicates success. 
        /// If the selected object is a region, one of the following values indicates success. 
        /// </returns>
        [DllImport("gdi32.dll", SetLastError = true)]
        internal static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        /// <summary>
        /// Deletes a logical pen, brush, font, bitmap, region, or palette, freeing all system resources associated with the object. 
        /// </summary>
        /// <param name="hObject">Handle to a logical pen, brush, font, bitmap, region, or palette.</param>
        /// <returns>
        /// Nonzero indicates success. 
        /// Zero indicates that the specified handle is not valid or that the handle is currently selected into a device context.
        /// </returns>
        [DllImport("gdi32.dll", SetLastError = true)]
        internal static extern int DeleteObject(IntPtr hObject);

        /// <summary>
        /// Deletes the specified device context.
        /// </summary>
        /// <param name="hdc">A handle to the device context.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </returns>
        [DllImport("gdi32.dll", SetLastError = true)]
        internal static extern int DeleteDC(IntPtr hdc);

        /// <summary>
        /// Set the pixels in the specified rectangle on the device that is associated with the destination device 
        /// context using color data from a DIB, JPEG, or PNG image.
        /// http://msdn.microsoft.com/en-us/library/dd162974(VS.85).aspx
        /// </summary>
        /// <param name="hdc">A handle to the device context.</param>
        /// <param name="XDest">The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
        /// <param name="YDest">The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
        /// <param name="dwWidth">The width, in logical units, of the image.</param>
        /// <param name="dwHeight">The height, in logical units, of the image.</param>
        /// <param name="XSrc">The x-coordinate, in logical units, of the lower-left corner of the image.</param>
        /// <param name="YSrc">The y-coordinate, in logical units, of the lower-left corner of the image.</param>
        /// <param name="uStartScan">The starting scan line in the image.</param>
        /// <param name="cScanLines">The number of DIB scan lines contained in the array pointed to by the lpvBits parameter.</param>
        /// <param name="lpvBits">A pointer to the color data stored as an array of bytes.</param>
        /// <param name="lpbmi">A pointer to a BITMAPINFOHEADER structure that contains information about the DIB.</param>
        /// <param name="fuColorUse">Indicates whether the bmiColors member of the BITMAPINFOHEADER structure contains explicit red, green, blue (RGB) values or indexes into a palette.</param>
        /// <returns>
        /// If the function succeeds, the return value is the number of scan lines set.
        /// If zero scan lines are set (such as when dwHeight is 0) or the function fails, the function returns zero.
        /// If the driver cannot support the JPEG or PNG file image passed to SetDIBitsToDevice, the function will fail and return GDI_ERROR. 
        /// </returns>
        [DllImport("gdi32.dll", SetLastError = true)]
        internal static extern int SetDIBitsToDevice(IntPtr hdc, int XDest, int YDest, uint dwWidth, uint dwHeight,
        int XSrc, int YSrc, uint uStartScan, uint cScanLines, byte[] lpvBits, [In] ref Structures.BITMAPINFO lpbmi, uint fuColorUse);

        /// <summary>
        /// Set the pixels in the specified rectangle on the device that is associated with the destination device 
        /// context using color data from a DIB, JPEG, or PNG image.
        /// http://msdn.microsoft.com/en-us/library/dd162974(VS.85).aspx
        /// </summary>
        /// <param name="hdc">A handle to the device context.</param>
        /// <param name="XDest">The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
        /// <param name="YDest">The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
        /// <param name="dwWidth">The width, in logical units, of the image.</param>
        /// <param name="dwHeight">The height, in logical units, of the image.</param>
        /// <param name="XSrc">The x-coordinate, in logical units, of the lower-left corner of the image.</param>
        /// <param name="YSrc">The y-coordinate, in logical units, of the lower-left corner of the image.</param>
        /// <param name="uStartScan">The starting scan line in the image.</param>
        /// <param name="cScanLines">The number of DIB scan lines contained in the array pointed to by the lpvBits parameter.</param>
        /// <param name="lpvBits">A pointer to the color data stored as an array of bytes.</param>
        /// <param name="lpbmi">A pointer to a BITMAPINFOHEADER structure that contains information about the DIB.</param>
        /// <param name="fuColorUse">Indicates whether the bmiColors member of the BITMAPINFOHEADER structure contains explicit red, green, blue (RGB) values or indexes into a palette.</param>
        /// <returns>
        /// If the function succeeds, the return value is the number of scan lines set.
        /// If zero scan lines are set (such as when dwHeight is 0) or the function fails, the function returns zero.
        /// If the driver cannot support the JPEG or PNG file image passed to SetDIBitsToDevice, the function will fail and return GDI_ERROR. 
        /// </returns>
        [DllImport("gdi32.dll", SetLastError = true)]
        internal static extern int SetDIBitsToDevice(IntPtr hdc, int XDest, int YDest, uint dwWidth, uint dwHeight,
        int XSrc, int YSrc, uint uStartScan, uint cScanLines, IntPtr lpvBits, IntPtr lpbmi, uint fuColorUse);

        /// <summary>
        /// Retrieves the bits of the specified compatible bitmap and copies them into a buffer as 
        /// a DIB using the specified format
        /// </summary>
        /// <param name="hdc">A handle to the device context.</param>
        /// <param name="hbmp">A handle to the bitmap. This must be a compatible bitmap (DDB).</param>
        /// <param name="uStartScan">The first scan line to retrieve.</param>
        /// <param name="cScanLines">The number of scan lines to retrieve.</param>
        /// <param name="lpvBits">A pointer to a buffer to receive the bitmap data.</param>
        /// <param name="lpbmi">A pointer to a BITMAPINFO structure that specifies the desired format for the DIB data.</param>
        /// <param name="uUsage">The format of the bmiColors member of the BITMAPINFO structure.</param>
        /// <returns>
        /// If the lpvBits parameter is non-NULL and the function succeeds, the return value is the number of scan lines copied from the bitmap.
        /// If the lpvBits parameter is NULL and GetDIBits successfully fills the BITMAPINFO structure, the return value is non-zero.
        /// If the function fails, the return value is zero.
        /// </returns>
        [DllImport("gdi32.dll", SetLastError = true)]
        internal static extern int GetDIBits(IntPtr hdc, IntPtr hbmp, uint uStartScan, uint cScanLines,
        [Out] byte[] lpvBits, [In] ref Structures.BITMAPINFO lpbmi, uint uUsage);

        /// <summary>
        /// Create a DIB that applications can write to directly. The function gives you a pointer to the location 
        /// of the bitmap bit values. You can supply a handle to a file-mapping object that the function will use 
        /// to create the bitmap, or you can let the system allocate the memory for the bitmap.
        /// </summary>
        /// <param name="hdc">Handle to a device context.</param>
        /// <param name="pbmi">A pointer to a BITMAPINFO structure that specifies various attributes of the DIB, including the bitmap dimensions and colors.</param>
        /// <param name="iUsage">The type of data contained in the bmiColors array member of the BITMAPINFO structure pointed to by pbmi (either logical palette indexes or literal RGB values).</param>
        /// <param name="ppvBits">A pointer to a variable that receives a pointer to the location of the DIB bit values.</param>
        /// <param name="hSection">A handle to a file-mapping object that the function will use to create the DIB. This parameter can be NULL.</param>
        /// <param name="dwOffset">The offset from the beginning of the file-mapping object referenced by hSection where storage for the bitmap bit values is to begin.</param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly created DIB, and *ppvBits points to the bitmap bit values.
        /// If the function fails, the return value is NULL, and *ppvBits is NULL.
        /// </returns>
        [DllImport("gdi32.dll", SetLastError = true)]
        internal static extern IntPtr CreateDIBSection(IntPtr hdc, [In] ref Structures.BITMAPINFO pbmi,
        uint iUsage, out IntPtr ppvBits, IntPtr hSection, uint dwOffset);

        /// <summary>
        /// Determines the location of the resource with the specified type, name, and language in the specified module.
        /// </summary>
        /// <param name="hModule">Handle to the module whose executable file contains the resource.</param>
        /// <param name="lpszType">Pointer to a null-terminated string specifying the type name of the resource.</param>
        /// <param name="lpszName">Pointer to a null-terminated string specifying the name of the resource.</param>
        /// <param name="wLanguage">Specifies the language of the resource.</param>
        /// <returns>If the function succeeds, the return value is a handle to the specified resource's information block.</returns>
        [DllImport("kernel32.dll", EntryPoint = "FindResourceExW", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern IntPtr FindResourceEx(IntPtr hModule, IntPtr lpszType, IntPtr lpszName, ushort wLanguage);

        /// <summary>
        /// Locks the specified resource in memory.
        /// </summary>
        /// <param name="hResData">Handle to the resource to be locked.</param>
        /// <returns>If the loaded resource is locked, the return value is a pointer to the first byte of the resource; otherwise, it is NULL.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr LockResource(IntPtr hResData);

        /// <summary>
        /// Loads the specified resource into global memory.
        /// </summary>
        /// <param name="hModule">Handle to the module whose executable file contains the resource.</param>
        /// <param name="hResData">Handle to the resource to be loaded.</param>
        /// <returns>If the function succeeds, the return value is a handle to the data associated with the resource.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr LoadResource(IntPtr hModule, IntPtr hResData);

        /// <summary>
        /// Returns the size, in bytes, of the specified resource. 
        /// </summary>
        /// <param name="hInstance">Handle to the module whose executable file contains the resource.</param>
        /// <param name="hResInfo">Handle to the resource. This handle must be created by using the FindResource or FindResourceEx function.</param>
        /// <returns>If the function succeeds, the return value is the number of bytes in the resource.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern int SizeofResource(IntPtr hInstance, IntPtr hResInfo);

        /// <summary>
        /// Closes an open object handle.
        /// </summary>
        /// <param name="hHandle">A valid handle to an open object.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool CloseHandle(IntPtr hHandle);

        /// <summary>
        /// Returns a handle to either a language-neutral portable executable file (LN file) or a 
        /// language-specific resource file (.mui file) that can be used by the UpdateResource function 
        /// to add, delete, or replace resources in a binary module.
        /// </summary>
        /// <param name="pFileName">Pointer to a null-terminated string that specifies the binary file in which to update resources.</param>
        /// <param name="bDeleteExistingResources">Specifies whether to delete the pFileName parameter's existing resources.</param>
        /// <returns>If the function succeeds, the return value is a handle that can be used by the UpdateResource and EndUpdateResource functions.</returns>
        [DllImport("kernel32.dll", EntryPoint = "BeginUpdateResourceW", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern IntPtr BeginUpdateResource(string pFileName, bool bDeleteExistingResources);

        /// <summary>
        /// Enumerates resource types within a binary module.
        /// </summary>
        /// <param name="hModule">Handle to a module to search.</param>
        /// <param name="lpEnumFunc">Pointer to the callback function to be called for each enumerated resource type.</param>
        /// <param name="lParam">Specifies an application-defined value passed to the callback function.</param>
        /// <returns>Returns TRUE if successful; otherwise, FALSE.</returns>
        [DllImport("kernel32.dll", EntryPoint = "EnumResourceTypesW", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool EnumResourceTypes(IntPtr hModule, EnumResourceTypesDelegate lpEnumFunc, IntPtr lParam);

        /// <summary>
        /// Loads the specified module into the address space of the calling process. 
        /// The specified module may cause other modules to be loaded.
        /// </summary>
        /// <param name="lpFileName">The name of the module.</param>
        /// <param name="hFile">This parameter is reserved for future use.</param>
        /// <param name="dwFlags">The action to be taken when loading the module.</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "LoadLibraryExW")]
        internal static extern IntPtr LoadLibraryEx(string lpFileName, IntPtr hFile, uint dwFlags);

        /// <summary>
        /// Frees the loaded dynamic-link library (DLL) module and, if necessary, decrements its reference count.
        /// </summary>
        /// <param name="hModule">A handle to the loaded library module.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool FreeLibrary(IntPtr hModule);

        /// <summary>
        /// Enumerates language-specific resources, of the specified type and name, associated with a binary module.
        /// </summary>
        /// <param name="hModule">The handle to a module to search.</param>
        /// <param name="lpszType">Pointer to a null-terminated string specifying the type of resource for which the language is being enumerated.</param>
        /// <param name="lpszName">Pointer to a null-terminated string specifying the name of the resource for which the language is being enumerated.</param>
        /// <param name="lpEnumFunc">Pointer to the callback function to be called for each enumerated resource language.</param>
        /// <param name="lParam">Specifies an application-defined value passed to the callback function.</param>
        /// <returns>Returns TRUE if successful or FALSE otherwise.</returns>
        [DllImport("kernel32.dll", EntryPoint = "EnumResourceLanguagesW", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool EnumResourceLanguages(IntPtr hModule, IntPtr lpszType, IntPtr lpszName, EnumResourceLanguagesDelegate lpEnumFunc, IntPtr lParam);

        /// <summary>
        /// Enumerates resources of a specified type within a binary module. 
        /// </summary>
        /// <param name="hModule">Handle to a module to search.</param>
        /// <param name="lpszType">Pointer to a null-terminated string specifying the type of the resource for which the name is being enumerated.</param>
        /// <param name="lpEnumFunc">Pointer to the callback function to be called for each enumerated resource name or ID.</param>
        /// <param name="lParam">Specifies an application-defined value passed to the callback function.</param>
        /// <returns>Returns TRUE if the function succeeds or FALSE if the function does not find a resource of the type specified, or if the function fails for another reason.</returns>
        [DllImport("kernel32.dll", EntryPoint = "EnumResourceNamesW", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool EnumResourceNames(IntPtr hModule, IntPtr lpszType, EnumResourceNamesDelegate lpEnumFunc, IntPtr lParam);

        /// <summary>
        /// Adds, deletes, or replaces a resource in a portable executable (PE) file. 
        /// There are some restrictions on resource updates in files that contain Resource Configuration (RC Config) data: 
        /// language-neutral (LN) files and language-specific resource (.mui) files.
        /// </summary>
        /// <param name="hUpdate">A module handle returned by the BeginUpdateResource function, referencing the file to be updated.</param>
        /// <param name="lpType">Pointer to a null-terminated string specifying the resource type to be updated.</param>
        /// <param name="lpName">Pointer to a null-terminated string specifying the name of the resource to be updated.</param>
        /// <param name="wLanguage">Specifies the language identifier of the resource to be updated.</param>
        /// <param name="lpData">Pointer to the resource data to be inserted into the file indicated by hUpdate.</param>
        /// <param name="cbData">Specifies the size, in bytes, of the resource data at lpData.</param>
        /// <returns>Returns TRUE if successful or FALSE otherwise.</returns>
        [DllImport("kernel32.dll", EntryPoint = "UpdateResourceW", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool UpdateResource(IntPtr hUpdate, IntPtr lpType, IntPtr lpName, ushort wLanguage, byte[] lpData, uint cbData);

        /// <summary>
        /// Commits or discards changes made prior to a call to UpdateResource.
        /// </summary>
        /// <param name="hUpdate">A module handle returned by the BeginUpdateResource function, and used by UpdateResource, referencing the file to be updated.</param>
        /// <param name="fDiscard">Specifies whether to write the resource updates to the file. If this parameter is TRUE, no changes are made. If it is FALSE, the changes are made: the resource updates will take effect.</param>
        /// <returns>Returns TRUE if the function succeeds; FALSE otherwise.</returns>
        [DllImport("kernel32.dll", EntryPoint = "EndUpdateResourceW", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool EndUpdateResource(IntPtr hUpdate, bool fDiscard);

        #endregion

        public const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
    }
}