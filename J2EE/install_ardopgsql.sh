#!/bin/bash

# NOTE: In a farm this needs to be executed in all frontends and the controller.

source /etc/sysconfig/outsystems

if [ -n "$WILDFLY_HOME" ]; then
	APP_SERVER_HOME=$WILDFLY_HOME
	USER=wildfly
fi

if [ -n "$JBOSS_HOME" ]; then
	APP_SERVER_HOME=$JBOSS_HOME
	USER=jboss
fi

if [ -z $APP_SERVER_HOME ]; then
	echo Unsupported app server. Only Wildfly and JBoss are supported for automatic installation.
	echo If you are using this in Weblogic, please get in contact with the author.
	exit
fi

umask 022

# this is for Wildfly or JBoss EAP 6.

mkdir -p $APP_SERVER_HOME/modules/outsystems/ardopgsql/
cp postgresql-9.4.1212.jar module.xml $APP_SERVER_HOME/modules/outsystems/ardopgsql/
cp ardo.databaseprovider.postgresql.jar $OUTSYSTEMS_HOME/plugins/database
cp postgresql-9.4.1212.jar $OUTSYSTEMS_HOME/lib

chown -R wildfly:wildfly $APP_SERVER_HOME/modules/outsystems/ardopgsql/
chown outsystems:outsystems $OUTSYSTEMS_HOME/plugins/database/ardo.databaseprovider.postgresql.jar
chown outsystems:outsystems $OUTSYSTEMS_HOME/lib/postgresql-9.4.1212.jar

$APP_SERVER_HOME/bin/jboss-cli.sh --user=osdeployservice --password=outsystems -c --command='/subsystem=ee:write-attribute(name=global-modules, value=[{"name" => "outsystems", "slot" => "main"},{"name" => "outsystems", "slot" => "ardopgsql"}])'

source /etc/outsystems/os.services.conf

if [ $CONTROLLER = ENABLED ]; then 
	$OUTSYSTEMS_HOME/configurationtool.sh /upgradeinstall /silent /scinstall
else
	service jboss-outsystems restart
	echo Don\'t forget to run this on all front-ends and also on the Controller
fi
