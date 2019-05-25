/*
 * @(#)DataInputStream.java     1.28 95/12/18 Arthur van Hoff
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
 * A data input stream that lets you read primitive Java data types
 * from a stream in a portable way.  Primitive data types are well
 * understood types with associated operations.  For example,
 * Integers are considered primitive data types.
 *
 * @see DataOutputStream
 * @version     1.28, 12/18/95
 * @author      Arthur van Hoff
 */
public
class LittleEndianDataInputStream extends FilterInputStream implements DataInput {

    private DataInputStream dis;

    /**
     * Creates a new DataInputStream.
     * @param in        the input stream
     */
    public LittleEndianDataInputStream(InputStream in) {
        super(in);
        dis = new DataInputStream(in);
    }

    /**
     * Reads data into an array of bytes.
     * This method blocks until some input is available.
     * @param b the buffer into which the data is read
     * @return  the actual number of bytes read, -1 is
     *          returned when the end of the stream is reached.
     * @exception IOException If an I/O error has occurred.
     */
    public final int read(byte b[]) throws IOException {
        return dis.read(b);
    }

    /**
     * Reads data into an array of bytes.
     * This method blocks until some input is available.
     * @param b the buffer into which the data is read
     * @param off the start offset of the data
     * @param len the maximum number of bytes read
     * @return  the actual number of bytes read, -1 is
     *          returned when the end of the stream is reached.
     * @exception IOException If an I/O error has occurred.
     */
    public final int read(byte b[], int off, int len) throws IOException {
        return dis.read(b, off, len);
    }

    /**
     * Reads bytes, blocking until all bytes are read.
     * @param b the buffer into which the data is read
     * @exception IOException If an I/O error has occurred.
     * @exception EOFException If EOF reached before all bytes are read.
     */
    public final void readFully(byte b[]) throws IOException {
        dis.readFully(b);
    }

    /**
     * Reads bytes, blocking until all bytes are read.
     * @param b the buffer into which the data is read
     * @param off the start offset of the data
     * @param len the maximum number of bytes read
     * @exception IOException If an I/O error has occurred.
     * @exception EOFException If EOF reached before all bytes are read.
     */
    public final void readFully(byte b[], int off, int len) throws IOException {
        dis.readFully(b, off, len);
    }

    /**
     * Skips bytes, blocks until all bytes are skipped.
     * @param n the number of bytes to be skipped
     * @return  the actual number of bytes skipped.
     * @exception IOException If an I/O error has occurred.
     */
    public final int skipBytes(int n) throws IOException {
        return dis.skipBytes(n);
    }

    /**
     * Reads a boolean.
     * @return the boolean read.
     */
    public final boolean readBoolean() throws IOException {
        return dis.readBoolean();
    }

    /**
     * Reads an 8 bit byte.
     * @return the 8 bit byte read.
     */
    public final byte readByte() throws IOException {
        return dis.readByte();
    }

    /**
     * Reads an unsigned 8 bit byte.
     * @return the 8 bit byte read.
     */
    public final int readUnsignedByte() throws IOException {
        return dis.readUnsignedByte();
    }


    /**
     * Reads a 16 bit short.
     * @return the 16 bit short read.
     */
    public final short readShort() throws IOException {
        InputStream in = this.in;
        int ch2 = in.read();
        int ch1 = in.read();
        if ((ch1 | ch2) < 0)
             throw new EOFException();
        return (short)((ch1 << 8) + (ch2 << 0));
    }


    /**
     * Reads 16 bit short.
     * @return the 16 bit short read.
     */
    public final int readUnsignedShort() throws IOException {
        InputStream in = this.in;
        int ch2 = in.read();
        int ch1 = in.read();
        if ((ch1 | ch2) < 0)
             throw new EOFException();
        return (ch1 << 8) + (ch2 << 0);
    }


    /**
     * Reads a 16 bit char.
     * @return the read 16 bit char.
     */
    public final char readChar() throws IOException {
        return dis.readChar();
    }

    /**
     * Reads a 32 bit int.
     * @return the 32 bit integer read.
     */
    public final int readInt() throws IOException {
        InputStream in = this.in;
        int ch4 = in.read();
        int ch3 = in.read();
        int ch2 = in.read();
        int ch1 = in.read();
        if ((ch1 | ch2 | ch3 | ch4) < 0)
             throw new EOFException();
        return ((ch1 << 24) + (ch2 << 16) + (ch3 << 8) + (ch4 << 0));
    }

    /**
     * Reads a 64 bit long.
     * @return the 64 bit long read.
     */
    public final long readLong() throws IOException {
        InputStream in = this.in;
        return (readInt() & 0xFFFFFFFFL) + (readInt() << 32L);
    }

    /**
     * Reads a 32 bit float.
     * @return the read 32 bit float.
     */
    public final float readFloat() throws IOException {
        return dis.readFloat();
    }

    /**
     * Reads a 64 bit double.
     * @return the 64 bit double read.
     */
    public final double readDouble() throws IOException {
        return dis.readDouble();
    }

    private char lineBuffer[];

    /**
     * Reads in a line that has been terminated by a \n, \r,
     * \r\n or EOF.
     * @return a String copy of the line.
     */
    public final String readLine() throws IOException {
		// SMC 447.5 JDK 1.1 fix
		//BufferedReader d = new BufferedReader(new InputStreamReader(in)); 
        //return d.readLine();
		return dis.readLine(); //depricated
    }

    /**
     * Reads a UTF format String.
     * @return the String.
     */
    public final String readUTF() throws IOException {
        return dis.readUTF();
    }
}


