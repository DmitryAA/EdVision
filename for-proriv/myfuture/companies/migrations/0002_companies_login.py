# Generated by Django 2.1 on 2019-06-23 05:06

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('companies', '0001_initial'),
    ]

    operations = [
        migrations.AddField(
            model_name='companies',
            name='login',
            field=models.CharField(default=None, max_length=150, verbose_name='Логин'),
            preserve_default=False,
        ),
    ]