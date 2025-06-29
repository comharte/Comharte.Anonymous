terraform {
  required_version = ">=1.0"
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~>3.0"
    }
    random = {
      source  = "hashicorp/random"
      version = "~>3.0"
    }
  }

  backend "azurerm" {
    resource_group_name  = "#resource_group_name"
    storage_account_name = "#storage_account_name"
    container_name       = "terraform-states-#environment"
    key                  = "anonymous.tfstate"
  }

}
provider "azurerm" {
  features {}
}

data "azurerm_client_config" "current" {}

data "azurerm_subscription" "primary" {}

data "terraform_remote_state" "global" {
  backend = "azurerm"
  config = {
    resource_group_name  = "#resource_group_name"
    storage_account_name = "#storage_account_name"
    container_name       = "terraform-states-global"
    key                  = "global.tfstate"
  }
}