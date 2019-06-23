# Generated by Django 2.1 on 2019-06-23 01:50

from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    dependencies = [
        ('universites', '0001_initial'),
    ]

    operations = [
        migrations.CreateModel(
            name='Department',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('name', models.CharField(max_length=100, verbose_name='Название кафедры')),
                ('id_Universities', models.ForeignKey(on_delete=django.db.models.deletion.PROTECT, to='universites.Universities')),
            ],
        ),
        migrations.CreateModel(
            name='Direction',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('name', models.CharField(max_length=100, verbose_name='Название направления')),
                ('description', models.CharField(max_length=100, verbose_name='Направление обучения')),
            ],
        ),
    ]