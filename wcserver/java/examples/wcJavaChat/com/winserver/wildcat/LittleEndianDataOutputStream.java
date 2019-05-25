/*
 * @(#)DataOutputStream.java    1.20 95/12/18 Arthur van Hoff
 *
 * Copyright (c) 1994 Sun Microsystems, Inc. All Rights Reserved.
 *
 * Permission to use, copy, modify, and distribute this software
 * and its documentation for NON-COMMERCIAL purposes and without
 * fee is hereby granted provided that this copyright notice
 * appears in all copies. Please refer to the file "copyright.html"
 * for further important copyright and licensing information.
 *
 * SUN MAKES NO REPRESENTATIONS OR WARRANTIES ABOUT THE SUITABILITY OF
 * THE SOFTWARE, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
 * TO THE IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
 * PARTICULAR PURPOSE, OR NON-INFRINGEMENT. SUN SHALL NOT BE LIABLE FOR
 * ANY DAMAGES SUFFERED BY LICENSEE AS A RESULT OF USING, MODIFYING OR
 * DISTRIBUTING THIS SOFTWARE OR ITS DERIVATIVES.
 */

package COM.winserver.wildcat;

import java.io.*;

/**
 * This class lets you write primitive Java data types
 * to a stream in a portable way. Primitive data types are well
 * understood types with associated operations.  For example, an
 * Integer is considered to be a good primitive data type.
 *
 * The data can be converted back using a DataInputStream.
 */

public
class LittleEndianDataOutputStream extends FilterOutputStream implements DataOutput {
    /**
     * The number of bytes written so far.
     */
    protected int written;
    private DataOutputStream dos;

    /**
     * Creates a new DataOutputStream.
     * @param out       the output stream
     */
    public LittleEndianDataOutputStream(OutputStream out) {
        super(out);
        dos = new DataOutputStream(out);
    }

    /**
     * Writes a byte. Will block until the byte is actually
     * written.
     * @param b the byte to be written
     * @exception IOException If an I/O error has occurred.
     */
    public synchronized void write(int b) throws IOException {
        dos.write(b);
    }

    /**
     * Writes a sub array of bytes.
     * @param b the data to be written
     * @param off       the start offset in the data
     * @param len       the number of bytes that are written
     * @exception IOException If an I/O error has occurred.
     */
    public synchronized void write(byte b[], int off, int len)
        throws IOException
    {
        dos.write(b, off, len);
    }

    /**
     * Flushes the stream. This will write any buffered
     * output bytes.
     * @exception IOException If an I/O error has occurred.
     */
    public void flush() throws IOException {
        dos.flush();
    }

    /**
     * Writes a boolean.
     * @param v the boolean to be written
     */
    public final void writeBoolean(boolean v) throws IOException {
        dos.writeBoolean(v);
    }

    /**
     * Writes an 8 bit byte.
     * @param v the byte value to be written
     */
    public final void writeByte(int v) throws IOException {
        dos.writeByte(v);
    }

    /**
     * Writes a 16 bit short.
     * @param v the short value to be written
     */
    public final void writeShort(int v) throws IOException {
        OutputStream out = this.out;
        out.write((v >>> 0) & 0xFF);
        out.write((v >>> 8) & 0xFF);
        written += 2;
    }

    /**
     * Writes a 16 bit char.
     * @param v the char value to be written
     */
    public final void writeChar(int v) throws IOException {
        dos.writeChar(v);
    }

    /**
     * Writes a 32 bit int.
     * @param v the integer value to be written
     */
    public final void writeInt(int v) throws IOException {
        OutputStream out = this.out;
        out.write((v >>>  0) & 0xFF);
        out.write((v >>>  8) & 0xFF);
        out.write((v >>> 16) & 0xFF);
        out.write((v >>> 24) & 0xFF);
        written += 4;
    }

    /**
     * Writes a 64 bit long.
     * @param v the long value to be written
     */
    public final void writeLong(long v) throws IOException {
        OutputStream out = this.out;
        out.write((int)(v >>>  0) & 0xFF);
        out.write((int)(v >>>  8) & 0xFF);
        out.write((int)(v >>> 16) & 0xFF);
        out.write((int)(v >>> 24) & 0xFF);
        out.write((int)(v >>> 32) & 0xFF);
        out.write((int)(v >>> 40) & 0xFF);
        out.write((int)(v >>> 48) & 0xFF);
        out.write((int)(v >>> 56) & 0xFF);
        written += 8;
    }

    /**
     * Writes a 32 bit float.
     * @param v the float value to be written
     */
    public final void writeFloat(float v) throws IOException {
        dos.writeFloat(v);
    }

    /**
     * Writes a 64 bit double.
     * @param v the double value to be written
     */
    public final void writeDouble(double v) throws IOException {
        dos.writeDouble(v);
    }

    /**
     * Writes a String as a sequence of bytes.
     * @param s the String of bytes to be written
     */
    public final void writeBytes(String s) throws IOException {
        dos.writeBytes(s);
    }

    /**
     * Writes a String as a sequence of chars.
     * @param s the String of chars to be written
     */
    public final void writeChars(String s) throws IOException {
        dos.writeChars(s);
    }

    /**
     * Writes a String in UTF format.
     * @param str the String in UTF format
     */
    public final void writeUTF(String str) throws IOException {
        dos.writeUTF(str);
    }

    /**
     * Returns the number of bytes written.
     * @return  the number of bytes written thus far.
     */
    public final int size() {
        return written + dos.size();
    }
}
