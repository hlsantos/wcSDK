## Wildcat! wcSDK Delphi Library and Examples
<pre>
Wildcat! SDK/API
(c) Copyright 1998-2024 Santronics Software, Inc. All Rights Reserved.

Version   : 8.0
Build     : 454.16
Date      : 03/17/25 10:22 pm
</pre>

This document describes how to configure and compile the Wildcat! Server Software Development Kit (wcSDK) libraries and examples using Delphi.

---

## Directory Structure

- **`\lib`** - Contains Delphi unit source files (`*.pas`) required to build wcSDK applications.
- **`\examples`** - Contains Delphi example applications demonstrating wcSDK usage.

---

## Prerequisites

- **Delphi for Win32 (32-bit)** compiler (Borland/Embarcadero).
- Recommended compiler: `dcc32.exe` (version 10.0 or newer).

Ensure your compiler (`dcc32.exe`) is available and properly configured in your system path or located in a known directory (e.g., `D:\bin`).

---

## Recommended Setup

To simplify your compilation process, configure your global Delphi configuration file (`dcc32.cfg`) located with your Delphi compiler executable (e.g., `D:\bin\dcc32.cfg`) with the following entries:

```ini
; Global Delphi Compiler Configuration for wcSDK

; Include files search path
-i\local\wcsdk\wcserver\delphi\lib

; Units search path
-u\local\wcsdk\wcserver\delphi\lib
```

Here, `\local\wcsdk` should be a junction or symbolic link to your active wcSDK repository, ensuring easy maintenance and updates.

Example command to create a junction (symbolic link) in Windows:
```batch
mklink /J \local\wcsdk \path\to\your\wc8\wcsdk
```

---

## Compiling wcSDK Examples

Navigate to your specific Delphi example folder and run the following command:

```batch
cd \local\wcsdk\wcserver\delphi\examples\door32
d:\bin\dcc32.exe door32-example1.pas
```

This will compile the Delphi example using the configured wcSDK library paths.

**Note:** Delphi version 10.0 (circa 1997) only supports loading `dcc32.cfg` from:
- The current working directory (preferred if customizing per-example).
- The compiler's executable directory (`dcc32.exe` location).

To avoid issues, ensure you always execute the `dcc32.exe` compiler from the example's directory containing the intended `dcc32.cfg` or configure globally as shown above.

---

## Verifying Your Setup

If compilation succeeds, an executable (`door32-example1.exe`) will be generated in the current folder.

To confirm your local paths and configuration file are correctly loaded, temporarily insert an invalid switch in your local `dcc32.cfg` file:

```ini
-invalidswitch
```

Compiling should immediately produce an error, confirming your local configuration is being used.

---

## Compatibility and Future Versions

Modern Delphi compilers (Embarcadero Delphi XE or later) support additional features:

- Explicit configuration files via command-line parameter: `--cfg=<configfile>`.
- Environment variables (e.g., `DCC32CFG`) for flexible configuration handling.

Please consult Embarcadero documentation for the exact capabilities of your compiler version.

---

## Support

For further assistance, please contact your wcSDK development support representative.

## History

- 454.15, 03/17/2025 - Updated the wcSDK for Delphi Pascal v3.0 (internal DCC32 version v100)
                     - added AnsiTerm.pas to lib
                     - Updated/Added wcDoor32 examples


