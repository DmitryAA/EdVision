<template>
	<div v-if="info" class="row b-university">
		<div class="b-university__info">
			<h1>{{info.Name}}</h1>
			<div><strong>Адрес</strong>: {{info.Address.City.Name}}</div>
			<div><strong>Средний рейтинг</strong>: {{info.FederalRating}}</div>
			<div><strong>Средняя стипендия</strong>: {{info.MeanGrants}}</div>
			<div><strong>Стоимость проживания</strong>: {{info.HostelPrice}}</div>
		</div>
		<div class="b-university__departments">
			<h2>Подразделения</h2>
			<section v-for="item in info.Departments">
				<article>
					<router-link :to="{ path: '/department/' + item.Id}">{{item.Name}}</router-link>
				</article>
			</section>
		</div>
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
				.get('http://192.168.0.30:1488/api/universities/' + this.$route.params.id)
				.then(response => {
					this.info = response.data;
				});
		}
	};
</script>
