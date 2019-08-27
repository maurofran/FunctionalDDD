namespace Iam.Common

open System

/// Useful functions for constrained types.
module ConstrainedType =
    /// Create a constrained string using the constructor provided
    /// Return Error if the input is null, empty or if length is > than maxLen
    let createString fieldName ctor maxLen str =
        if String.IsNullOrEmpty(str) then
            sprintf "%s must not be null or empty" fieldName |> Error
        elif str.Length > maxLen then
            sprintf "%s must not be more than %i characters" fieldName maxLen |> Error
        else
            ctor str |> Ok

    /// Create a constrained optional string using the constructor provided
    /// Return None if input is null or empty, Some if input is valid and Error if length is > than maxLen 
    let createStringOption fieldName ctor maxLen str =
        if String.IsNullOrEmpty(str) then
            None |> Ok
        elif str.Length > maxLen then
            sprintf "%s must not be more than %i characters" fieldName maxLen |> Error
        else
            ctor str |> Some |> Ok

    /// Create a constrained string using the constructor provided
    /// Return Error if input is null, empty or does not match the regex pattern
    let createStringLike fieldName ctor pattern str =
        if String.IsNullOrEmpty(str) then
            sprintf "%s must not be null or empty" fieldName |> Error
        elif System.Text.RegularExpressions.Regex.IsMatch(str, pattern) then
            ctor str |> Ok
        else
            sprintf "%s must match the pattern '%s'" fieldName pattern |> Error

    let createStringOptionLike fieldName ctor pattern str =
        if String.IsNullOrEmpty(str) then
            None |> Ok
        elif System.Text.RegularExpressions.Regex.IsMatch(str, pattern) then
            ctor str |> Some |> Ok
        else
            sprintf "%s must match the pattern '%s'" fieldName pattern |> Error
