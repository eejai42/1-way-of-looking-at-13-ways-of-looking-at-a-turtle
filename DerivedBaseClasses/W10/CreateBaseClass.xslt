<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

    <xsl:param name="output-filename" select="'output.txt'" />

    <xsl:template match="@* | node()">
        <xsl:copy>
            <xsl:apply-templates select="@* | node()"/>
        </xsl:copy>
    </xsl:template>

    <xsl:template match="/*">
        <FileSet>
            <FileSetFiles>
                <FileSetFile>
                    <RelativePath>
                        <xsl:text>../W10Base.fsx</xsl:text>
                    </RelativePath>
                    <xsl:element name="FileContents" xml:space="preserve">(* ======================================
10-EventSourcing.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Way 10: Event sourcing -- Building state from a list of past events

In this design, the client sends a `Command` to a `CommandHandler`.
The CommandHandler converts that to a list of events and stores them in an `EventStore`.

In order to know how to process a Command, the CommandHandler builds the current state
from scratch using the past events associated with that particular turtle.

Neither the client nor the command handler needs to track state.  Only the EventStore is mutable.
====================================== *)

#load "../Common.fsx"

open Common

// ======================================
// FP Turtle
// ======================================

// see code in this file
#load "../FPTurtleLib.fsx"
open FPTurtleLib

// ======================================
// Way 10 Helper Classes
// ======================================

module W10Base = 

    /// Function to log a message
    let log message =
        printfn "%s" message 

    <xsl:for-each select="//PredifinedScript">
    <xsl:variable name="pds-name" select="Name" />
    let draw<xsl:value-of select="$pds-name" />() = 
        printfn "PRINTING <xsl:value-of select="$pds-name" />!"
        // let turtle = Turtle(log)
        <xsl:for-each select="//PredifinedScriptStep[normalize-space(PredefinedScript) = $pds-name]"><xsl:if test="normalize-space(Description) != ''">
        // <xsl:value-of select="Description" /></xsl:if><xsl:text>
        // turtle.</xsl:text><xsl:value-of select="Command" /> <xsl:value-of select="Argument" /><xsl:choose>
            <xsl:when test="ArgumentType = 'Degrees'">.0&lt;Degrees></xsl:when>
            <xsl:when test="ArgumentType = 'Distance'">.0</xsl:when>
            <xsl:when test="normalize-space(ArgumentType) = ''">()</xsl:when>
        </xsl:choose></xsl:for-each>
    </xsl:for-each>
    

</xsl:element>
                </FileSetFile>
            </FileSetFiles>
        </FileSet>
    </xsl:template>
</xsl:stylesheet>
