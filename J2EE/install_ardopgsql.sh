#!/bin/bash

source /etc/sysconfig/outsystems

umask 022

# this is for jboss 7 / jboss 6 eap.

mkdir -p $JBOSS_HOME/modules/outsystems/ardopgsql/
cp postgresql-9.3-1102.jdbc3.jar module.xml $JBOSS_HOME/modules/outsystems/ardopgsql/
cp postgresqldatabaseprovider.jar $OUTSYSTEMS_HOME/plugins/database
cp postgresql-9.3-1102.jdbc3.jar $OUTSYSTEMS_HOME/lib

chown -R jboss:jboss $JBOSS_HOME/modules/outsystems/ardopgsql/
chown outsystems:outsystems $OUTSYSTEMS_HOME/plugins/database/postgresqldatabaseprovider.jar
chown outsystems:outsystems $OUTSYSTEMS_HOME/lib/postgresql-9.3-1102.jdbc3.jar

$JBOSS_HOME/bin/jboss-cli.sh -c --command='/subsystem=ee:write-attribute(name=global-modules, value=[{"name" => "outsystems", "slot" => "main"},{"name" => "outsystems", "slot" => "ardopgsql"}])'

$OUTSYSTEMS_HOME/configurationtool.sh /upgradeinstall /silent /scinstall
