<template>
	<div v-if="info">
		<h1>{{info.Name}}</h1>
		<div>По заказу: {{info.Company.LegalName}}</div>
		<p>{{info.Comment}}</p>
		<h2>Задачи</h2>
		<section v-for="item in info.Tasks">
			<article>
				<h3>{{item.Name}}</h3>
				<div><strong>Дата сдачи</strong>: {{item.EndDate}} </div>
				<div><strong>Резюме преподователя ({{item.LecturerGrade.GradingPerson.LastName}})</strong>: {{item.LecturerGrade.Comment}} </div>
				<div><strong>Резюме ментора ({{item.MentorGrade.GradingPerson.LastName}})</strong>: {{item.MentorGrade.Comment}} </div>
			</article>
		</section>
	</div>
</template>

<script>
	import axios from 'axios';

	export default {
		name: 'university',
		data() {
			return {
				info: null,
			};
		},
		mounted() {
			axios
				.get('http://192.168.0.30:1488/api/projects/' + this.$route.params.id)
				.then(response => {
					this.info = response.data;
				});
		}
	};
</script>
