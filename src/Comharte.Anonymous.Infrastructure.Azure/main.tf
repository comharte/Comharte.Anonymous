module "services" {
  source = var.module_services_path

	service_code = "anonymous"
	environment = var.environment
	with_app_service = true
	with_mssql_database = true    
}

output "server_as_default_hostname" {
  value = module.services.server_as_default_hostname
}