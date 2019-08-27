namespace Iam.Domain

open Iam.Common

type TenantId = private TenantId of string

module TenantId =
    /// Return the value inside a TenantId
    let value (TenantId str) = str
    
    let create fieldName str =
        ConstrainedType.createStringLike fieldName TenantId "[({]?[a-fA-F0-9]{8}[-]?([a-fA-F0-9]{4}[-]?){3}[a-fA-F0-9]{12}[})]?" str

module Tenant =
    type Command = Nothing
    type Event = Nothing
    
    type State = {
        TenantId: TenantId
        Name: String35
        Description: String150 option
        Active: bool
    }

